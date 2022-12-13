﻿namespace ProductManager.Domain.Models
{
    public class PaginationModel
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
