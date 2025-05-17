using System;
using System.Collections.Generic;

namespace THADotNetTrainingBatch1.Project1.Database.Models;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string ProductCode { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public int? ProductCategory { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public DateTime CreateDateTime { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedDateTime { get; set; }

    public int? ModifiedBy { get; set; }
}
