namespace Medialibrary.Interfaces.Playlist
{
    public interface IPlaylistFunctionality<TFile>
    {
        void AddFile(TFile file);
        void DeleteFile(TFile file);

    }
}
