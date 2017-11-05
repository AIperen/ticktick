using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class SpriteGameObject : GameObject
{
    protected SpriteSheet sprite;
    protected Vector2 origin;
    public bool PerPixelCollisionDetection = true;
    public bool CameraFollow ;                  //
    public bool ParallaxFollow;                 //zorgt er voor dat wanneer true Parallax follow aan staat

    public SpriteGameObject(string assetName, int layer = 0, string id = "", int sheetIndex = 0, bool CameraFollow = true, bool ParallaxFollow = false)
        : base(layer, id)
    {
        this.CameraFollow = CameraFollow;       //              
        

        if (assetName != "")
        {
            sprite = new SpriteSheet(assetName, sheetIndex);
        }
        else
        {
            sprite = null;
        }
    }    

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        Camera camera = GameEnvironment.Camera;                                     
        
        if (!visible || sprite == null)                                             // visible op 'niet waar' en sprite op null draw niks
        {
            return;
        }
        if (CameraFollow == true && ParallaxFollow == false)                        //als de camera 'aan' staat, maar de parallaxFollow uit: draw alleen ten opzichte van de camera.Position
        {
            sprite.Draw(spriteBatch, this.GlobalPosition - camera.Position,origin);
            
        }
        else if (CameraFollow == false)                                             //als cameraFollow 'uit'staat, draw op gwn positie
        {    
            sprite.Draw(spriteBatch, this.GlobalPosition, origin);
        }
       if (ParallaxFollow == true)                                                  //Als parralaxFollow 'aan' staat, krijg je dus meerdere lagen die ten opzichte van elkaar ook nog eens bewegen
        {
            sprite.Draw(spriteBatch, new Vector2( this.GlobalPosition.X - camera.Position.X * 0.25f * layer, GlobalPosition.Y - camera.Position.Y), origin);
        }

    }

    public SpriteSheet Sprite
    {
        get { return sprite; }
    }

    public Vector2 Center
    {
        get { return new Vector2(Width, Height) / 2; }
    }

    public int Width
    {
        get
        {
            return sprite.Width;
        }
    }

    public int Height
    {
        get
        {
            return sprite.Height;
        }
    }

    public bool Mirror
    {
        get { return sprite.Mirror; }
        set { sprite.Mirror = value; }
    }

    public Vector2 Origin
    {
        get { return origin; }
        set { origin = value; }
    }

    public override Rectangle BoundingBox
    {
        get
        {
            int left = (int)(GlobalPosition.X - origin.X);
            int top = (int)(GlobalPosition.Y - origin.Y);
            return new Rectangle(left, top, Width, Height);
        }
    }

    public bool CollidesWith(SpriteGameObject obj)
    {
        if (!visible || !obj.visible || !BoundingBox.Intersects(obj.BoundingBox))
        {
            return false;
        }
        if (!PerPixelCollisionDetection)
        {
            return true;
        }
        Rectangle b = Collision.Intersection(BoundingBox, obj.BoundingBox);
        for (int x = 0; x < b.Width; x++)
        {
            for (int y = 0; y < b.Height; y++)
            {
                int thisx = b.X - (int)(GlobalPosition.X - origin.X) + x;
                int thisy = b.Y - (int)(GlobalPosition.Y - origin.Y) + y;
                int objx = b.X - (int)(obj.GlobalPosition.X - obj.origin.X) + x;
                int objy = b.Y - (int)(obj.GlobalPosition.Y - obj.origin.Y) + y;
                if (sprite.IsTranslucent(thisx, thisy) && obj.sprite.IsTranslucent(objx, objy))
                {
                    return true;
                }
            }
        }
        return false;
    }
}

