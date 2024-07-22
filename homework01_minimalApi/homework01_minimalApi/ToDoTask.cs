using System;
using System.Collections.Generic;

namespace homework01_minimalApi;

public partial class ToDoTask
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsDone { get; set; }

    public DateOnly Due { get; set; }
}
