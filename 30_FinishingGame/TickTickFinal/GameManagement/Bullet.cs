using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

class Bullet : SpriteGameObject
{
    public Bullet( Vector2 position, int layer = 0, string id = "") : base ("bullet", layer, id)
    {
        this.position.Y = position.Y - 50;
        this.position.X = position.X + 50;
        this.velocity = new Vector2(300, 0);
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        HitEnemies();
    }

    public bool HitEnemies()
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
   

