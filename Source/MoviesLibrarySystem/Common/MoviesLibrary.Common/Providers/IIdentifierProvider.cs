namespace MoviesLibrary.Common
{
    public interface IIdentifierProvider
    {
        int DecodeId(string urlId);

        string EncodeId(int id);
    }
}
