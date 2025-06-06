﻿using System;
using System.Collections.Generic;

namespace THADotNetTrainingBatch1.Assi.Database.Models;

public partial class TblHomework
{
    public int No { get; set; }

    public string Name { get; set; } = null!;

    public string? GitHubUserName { get; set; }

    public string? GitHubRepoLink { get; set; }
}
