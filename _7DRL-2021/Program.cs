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
        private static Font font;
        
        static void Main(string[] args)
        {
            SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING);
            var success = SDL.SDL_CreateWindowAndRenderer(256, 192, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN, out IntPtr window, out IntPtr renderer);
            SDL.SDL_SetWindowTitle(window, "DisasterMech");

            IntPtr fontSurf = SDL.SDL_LoadBMP("data/8x8font.bmp");
            IntPtr fontTex = SDL.SDL_CreateTextureFromSurface(renderer, fontSurf);
            font = new Font(fontTex, 64, 64, "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!\"", 8, 8);

            bool isRunning = true;
            while (true == isRunning) {
                SDL.SDL_RenderClear(renderer);
                while (1 == SDL.SDL_PollEvent(out SDL.SDL_Event evnt)) {
                    switch (evnt.type) {
                        case SDL.SDL_EventType.SDL_QUIT:
                            isRunning = false;
                        break;
                    }
                }

                font.WriteText(renderer, "Hello World!\"", 10, 10);
                SDL.SDL_RenderPresent(renderer);
            }
            
            SDL.SDL_DestroyTexture(fontTex);
            SDL.SDL_FreeSurface(fontSurf);

            SDL.SDL_DestroyWindow(window);
            SDL.SDL_DestroyRenderer(renderer);
        }
    }
}
