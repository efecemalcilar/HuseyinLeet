namespace Translator.UI.Models
{
    public class FilterTranslationHistoryViewModel
    {
        public int Id { get; set; }
        public DateTime MinDate { get; set; } = DateTime.MinValue;
        public DateTime MaxDate { get; set; } = DateTime.MaxValue;
        public string Text { get; set; } = "";
        public string Translation { get; set; } = "";
    }
}
