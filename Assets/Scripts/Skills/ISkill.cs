namespace Skills
{
    public interface ISkill
    {
        string Name { get; }
        float Damage { get; }
        
        void Use();
    }
}