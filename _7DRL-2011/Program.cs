using System;
using SDL2;

/*
 * 7DRL 2021 - DisasterMech
 * (c) Arcade Badgers Limited
 */

namespace _7DRL_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING);
            var success = SDL.SDL_CreateWindowAndRenderer(320, 200, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN,
                out IntPtr window, out IntPtr renderer);

            bool isRunning = true;
            while (true == isRunning) {
                while (1 == SDL.SDL_PollEvent(out SDL.SDL_Event evnt)) {
                    switch (evnt.type) {
                        case SDL.SDL_EventType.SDL_QUIT:
                            isRunning = false;
                        break;
                    }
                }
                SDL.SDL_RenderClear(renderer);
            }

            SDL.SDL_DestroyWindow(window);
            SDL.SDL_DestroyRenderer(renderer);
        }
    }
}
