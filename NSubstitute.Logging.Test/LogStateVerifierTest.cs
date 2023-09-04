using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using NSubstitute.Logging.Internals;
using Xunit;

namespace NSubstitute.Logging.Test
{
    [Trait("Category", "Unit")]
    public class LogStateVerifierTest
    {
        [Fact]
        public void WorksWithEmptyState()
        {
            IReadOnlyList<KeyValuePair<string, object>> state = new List<KeyValuePair<string, object>>
            {

            };

            var target = new LogStateVerifier(state);

            Assert.Same(state, target.State);
        }

        [Fact]
        public void WorksWithNonEmptyState()
        {
            var now = DateTimeOffset.UtcNow;
            IReadOnlyList<KeyValuePair<string, object>> state = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("thing1", 1),
                new KeyValuePair<string, object>("{now", now),
            };

            var target = new LogStateVerifier(state);

            Assert.Same(state, target.State);
        }

        [Fact]
        public void CanGetValues()
        {
            var now = DateTimeOffset.UtcNow;
            IReadOnlyList<KeyValuePair<string, object>> state = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("thing1", 1),
                new KeyValuePair<string, object>("{now", now),
            };

            var target = new LogStateVerifier(state);

            if (target.TryGetValue("thing1", out int actualThing1))
            {
                Assert.Equal(1, actualThing1);
            }
            else
            {
                Assert.True(false); // could not get value but expected to
            }

            if (target.TryGetValue("{now", out DateTimeOffset actualNow))
            {
                Assert.Equal(actualNow, now);
            }
            else
            {
                Assert.True(false); // could not get value but expected to
            }
        }

        [Fact]
        public void CannotGetValuesThatAreNotThere()
        {
            IReadOnlyList<KeyValuePair<string, object>> state = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("item", 1)
            };

            var target = new LogStateVerifier(state);

            Assert.False(target.TryGetValue("item1", out int actualItem1));
            Assert.False(target.TryGetValue("now", out DateTimeOffset actualNow));

            Assert.True(target.TryGetValue("item", out int actualItemInt)); // this works
            Assert.Equal(1, actualItemInt);

            var ex = Assert.Throws<InvalidCastException>(() =>
            {
                // wrong type, won't work
                target.TryGetValue("item", out string actualItemString);
            });

            Assert.Contains("System.Int32", ex.Message);
            Assert.Contains("System.String", ex.Message);
        }

        [Fact]
        public void MessageTemplate_SameWhenProvided()
        {
            string messageTemplate = "I am the log";
            IReadOnlyList<KeyValuePair<string, object>> state = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("{OriginalFormat}", messageTemplate)
            };

            var target = new LogStateVerifier(state);

            Assert.NotNull(target.MessageTemplate);
            Assert.Same(messageTemplate, target.MessageTemplate);
        }

        [Fact]
        public void MessageTemplate_NoErrorWhenNotProvided()
        {
            IReadOnlyList<KeyValuePair<string, object>> state = new List<KeyValuePair<string, object>>();

            var target = new LogStateVerifier(state);

            Assert.Null(target.MessageTemplate);
            Assert.Same(default(string), target.MessageTemplate);
        }
    }
}
