abstract class Character
{
    private string _character;
    protected bool _vulnerable;

    protected Character(string characterType)
    {
        _character = characterType;
        _vulnerable = false;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => _vulnerable;

    public override string ToString() => $"Character is a {_character}";
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target) => (target.Vulnerable()) ? 10 : 6;
}

class Wizard : Character
{
    public Wizard() : base("Wizard")
    {
        _vulnerable = true;
    }

    public override int DamagePoints(Character target) => (_vulnerable) ? 3 : 12;

    public void PrepareSpell()
    {
        _vulnerable = false;
    }
}
