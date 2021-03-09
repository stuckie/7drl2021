using SDL2;

namespace _7DRL_2021
{
    public class Viewport
    {
        private SDL.SDL_Rect view;
        private SDL.SDL_Rect port;

        public Viewport(SDL.SDL_Rect _view, SDL.SDL_Rect _port)
        {
            view = _view;
            port = _port;
        }

        public void Move(Point _point)
        {
            port.x = _point.x;
            port.y = _point.y;
        }

        public void Scroll(Point _point)
        {
            port.x += _point.x;
            port.y += _point.y;
        }

        public void ResizePort(SDL.SDL_Rect _port)
        {
            port = _port;
        }

        public void ResizeView(SDL.SDL_Rect _view)
        {
            view = _view;
        }
    }
}