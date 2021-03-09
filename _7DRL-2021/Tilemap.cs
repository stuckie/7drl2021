namespace _7DRL_2021
{
    public class Tilemap
    {
        private readonly uint[] tiles;
        private readonly uint width;
        private readonly uint height;

        public Tilemap(uint _width, uint _height)
        {
            width = _width;
            height = _height;
            tiles = new uint[width * height];
        }

        public uint at(Point _point)
        {
            return tiles[_point.y * width + _point.x];
        }
    }
}