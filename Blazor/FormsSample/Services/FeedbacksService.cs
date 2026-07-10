using FormsSample.Models;

namespace FormsSample.Services;

/// <summary>
/// Provides access to feedbacks added to the service.
/// This is mocked behaviour to view the UI in action only.
/// Usually this service would retrieve values from an API or database.
/// </summary>
public class FeedbacksService
{
    /// <summary>
    /// Stores feedbacks to be presented.
    /// </summary>
    public List<Feedback> feedbacks = [];

    /// <summary>
    /// Gets all the feedbacks stored in memory.
    /// </summary>
    /// <returns>A collection of feedbacks.</returns>
    public IEnumerable<Feedback> GetAll() => this.feedbacks;

    /// <summary>
    /// Adds a feedback to the collection in the memory.
    /// </summary>
    /// <param name="feedback">The feedback to add.</param>
    public void Add(Feedback feedback)
    {
        if (feedback is null)
        {
            return;
        }

        this.feedbacks.Add(feedback);
    }
}
