namespace LuckyWiki.Data {
    public interface ILuckyWikiDataProvider {
        IWikiPageRepository WikiPageRepository { get; }
        IMembershipRepository MembershipRepository { get; }
    }
}
