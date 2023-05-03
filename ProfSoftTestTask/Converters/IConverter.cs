public interface IConverter<Tin, Tout> 
{
    public Tout Convert(Tin input);
}
