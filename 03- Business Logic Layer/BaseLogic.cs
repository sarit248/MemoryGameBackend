using System;

namespace Match_Memory_Game
{
    public class BaseLogic : IDisposable
    {
        protected memorygameEntities DB = new memorygameEntities();

        public void Dispose()//Implementing the interface
        {
            DB.Dispose(); // שחרור משאבים
        }
    }
   
}
