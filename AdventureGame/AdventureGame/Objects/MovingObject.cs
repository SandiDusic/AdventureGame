﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Sandi_s_Way;
using Debugging;


namespace AdventureGameNamespace
{
    public abstract class MovingObject : GameObject
    {
        public MovingObject()
            : base()
        {
        }
        public MovingObject(Vector2 position)
            : base(position)
        {
        }

        protected void TryStep(float angle, int distance)
        {
            StepAngle(angle, distance);

            bool ranIntoWall = false;
            List<GameObject> solids = ObjectManager.Objects.Where(obj => obj is SolidObject).ToList();
            foreach (var solid in solids)
            {
                if (IsColliding(solid))
                {
                    ranIntoWall = true;
                    break;
                }
            }

            if (ranIntoWall)
            {
                StepAngle(angle, -distance);
            }
        }
    }
}
