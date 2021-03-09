using System;
using System.Collections.Generic;
using SDL2;

namespace _7DRL_2021
{
    public class Font
    {
        private IntPtr texture;
        private readonly string layout;
        private readonly int width;
        private readonly int height;
        private readonly int texWidth;
        private readonly int texHeight;
        private Dictionary<char, SDL.SDL_Rect> glyphs;

        public Font(IntPtr _texture, int _texWidth, int _texHeight, string _layout, int _width, int _height)
        {
            texture = _texture;
            layout = _layout;
            width = _width;
            height = _height;
            texWidth = _texWidth;
            texHeight = _texHeight;

            CalculateGlyphs();
        }

        public SDL.SDL_Rect GetGlyph(char _c) => false == glyphs.TryGetValue(_c, out var glyph) 
                                                ? new SDL.SDL_Rect() {x = -1, y = -1, w = -1, h = -1} 
                                                : glyph;

        public void WriteText(IntPtr renderer, string _text, int _x, int _y)
        {
            SDL.SDL_Rect pos = new SDL.SDL_Rect() {x = _x, y = _y, w = width, h = height};
            SDL.SDL_Rect glyph;
            foreach (var c in _text)
            {
                glyph = GetGlyph(c);
                SDL.SDL_RenderCopy(renderer, texture, ref glyph, ref pos);
                pos.x += width;
            }
        }

        private void CalculateGlyphs()
        {
            var x = 0;
            var y = 0;

            glyphs = new Dictionary<char, SDL.SDL_Rect>();
            
            foreach (var c in layout)
            {
                SDL.SDL_Rect glyph = new SDL.SDL_Rect() { x = x, y = y, w = width, h = height };
                if (false == glyphs.TryAdd(c, glyph)) break; /* bad layout */
                x = (x + width) % texWidth;
                if (0 == x)
                {
                    y = (y + height) % texHeight;
                    if (0 == y) break; /* too many glyphs, not enough texture */
                }
            }
        }
    }
}