using System;
using SDL2;

namespace _7DRL_2021
{
    public class Sprite
    {
        private IntPtr texture;
        private Point position;
        private SDL.SDL_Rect rect;

        public Sprite(IntPtr _texture, Point _position)
        {
            texture = _texture;
            position = _position;
            rect = new SDL.SDL_Rect() {x = 0, h = 8, w = 8, y = 0};
        }
        
        
    }
}