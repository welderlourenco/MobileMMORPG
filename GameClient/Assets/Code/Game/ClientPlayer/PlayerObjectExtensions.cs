﻿using Client.Net;
using MapHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Game.ClientPlayer
{
    public static class PlayerObjectExtensions
    {
        public static void TeleportToTile(this PlayerWrapper player, int x,  int y)
        {
            player.PlayerObject.transform.position = new Vector2(x * 16, -y * 16);
            UnityClient.Player.Position.X = x;
            UnityClient.Player.Position.Y = y;
        }

        public static bool FindPathTo(this PlayerWrapper player, Position position)
        {
            var path = WorldMap<Chunk>.FindPath(player.Position, position, UnityClient.Map.Chunks);
            if (path != null)
            {
                player.FollowingPath = path;
            }
            return path != null;
        }
    }
}
