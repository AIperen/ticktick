using Microsoft.Xna.Framework;

public class Camera : GameObject 
{
    public Camera() : base(0, "camera")
    {
        position = new Vector2(0, 0);                   //position van de camera
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }
}
