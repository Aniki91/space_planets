using System;

namespace spaceFlight
{
#if WINDOWS || XBOX
    static class Program
    {
        static void Main(string[] args)
        {
            using (spaceGame game = new spaceGame())
            {
                game.Run();
            }
        }
    }
#endif
}

