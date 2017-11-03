using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Bullet : SpriteGameObject
{
    public Bullet(string assetName, int layer = 0, string id = "", int sheetIndex = 0, bool CameraFollow = true, bool ParallaxFollow = false) 
        : base(assetName, layer, id, sheetIndex, CameraFollow, ParallaxFollow)
    {

    }
   
}
   

