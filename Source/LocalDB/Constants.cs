namespace LocalDB
{
    public class Constants
    {
        public const int PAGE_SIZE = 8192;
        public const int PAGE_HEADER_SIZE = 32;
        public const int PAGE_BODY_SIZE = PAGE_SIZE - PAGE_HEADER_SIZE;
    }
}
