using System.ComponentModel.DataAnnotations;

namespace AgenceIntro.Domain.Dto
{
    public class PaginationResult
    {
        public PaginationResult(int skipCount, int maxCount, string sortBy)
        {
            SkipCount = skipCount;
            MaxCount = maxCount;
            SortBy = sortBy;
        }

        [Required]
        public int SkipCount { get; set; }

        [Required]
        public int MaxCount { get; set; }

        public string SortBy { get; set; }
    }
}
