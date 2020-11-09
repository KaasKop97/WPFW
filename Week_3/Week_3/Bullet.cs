using System;

namespace Week_3{
    public class Bullet{
        public int Ypos;
        public int Xpos;

        public void move(){
            while(Ypos>Console.WindowHeight){
                Ypos += 1.5;
            }
        }

        public Bullet(int Xpos, int Ypos){
            Console.Write("|");
        }
        
    }
}