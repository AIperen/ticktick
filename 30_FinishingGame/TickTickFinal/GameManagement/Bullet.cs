using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
 
class Bullet : SpriteGameObject
{
    public Bullet( Vector2 position, int layer = 0, string id = "") : base ("bullet", layer, id)
    {   //Bullet Position
        this.position.Y = position.Y - 50; 
        this.position.X = position.X + 50;

    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        HitEnemies();
    }

    public bool HitEnemies()                    //checkt collision met enemies en zet ze op Visible = false wanneer dit het geval is
    {
        GameObjectList enemies = GameWorld.Find("enemies") as GameObjectList;
        if (enemies != null)
        {
            foreach (GameObject enemy in enemies.Children)
            {
                SpriteGameObject spriteEnemy = (SpriteGameObject)enemy;
                if (CollidesWith(spriteEnemy) && visible)
                {
                    spriteEnemy.Visible = false;
                }
            }
        }
        return true;
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        base.Draw(gameTime, spriteBatch);
    }
}
   

