    bool Collides (IEntityBox p, IEntityBox e) {
        bool noCollisionX = (p.X + p.W < e.X) || (e.X + e.W < p.X);
        bool collisionX = !noCollisionX;
        bool noCollisionY = (p.Y + p.H < e.Y) || (e.Y + e.H < p.Y);
        bool collisionY = !noCollisionY;
        // not that the collision on BOTH axises must be fulfilled
        return collisionX && collisionY;
     }
