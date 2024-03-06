namespace Eval_D2_P2.Entity
{
    public class Event
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = default!;

        public string Description { get; set; } = default!;

        public DateTime Date { get; set; }

        public string Location { get; set; } = default!;
    }
}
