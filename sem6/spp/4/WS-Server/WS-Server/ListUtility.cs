namespace WS_Server
{
    public static class ListUtility<T>
    {
        public static T GetRandom(IList<T> list)
        {
            return list[new Random().Next(list.Count)];
        }
    }
}
