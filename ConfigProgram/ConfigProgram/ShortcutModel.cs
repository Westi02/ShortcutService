public class ShortcutModel
{
    public List<Shortcut> Shortcuts { get; set; }
}

public class Shortcut
{
    public string Name { get; set; }
    public string ShortcutString { get; set; }
    public string ProgramPath { get; set; }
}

