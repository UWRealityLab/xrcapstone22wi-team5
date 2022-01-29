# Week 4 - Basic features, liquid physics,

## What we have accomplished

- Johnathon: Started project wiki, wrote pouring and filling scripts for
  liquids, made interactable prefabs for kitchen environment, fixed
  player/object collisions
- Katherine: Implemented a basic UI system for seeing object information (item
  name, temperature).
- Laksh: Added Network Manager and Player scripts and components. Added Player
  and hand Prefabs.
- Hritik: Created two different textures for fries (cooked and uncooked). Made
  it such that the texture changed when the fries reach the required
  temperature.

## New features/functionality implemented

- Interactable kitchen fixtures! Knobs can be turned, doors and drawers can be
  opened, and objects properly interact with them due to compound primitive hit
  boxes
- Liquid containers! Containers can be filled, pour liquid, or be scooped from
  using a single script. These containers visibly transform depending on how
  much liquid they are holding
- Ladle! A working ladle. Not much more to say
- Players can now see their own animated hands to show gripping and trigger
  controls.
- All players are now connected to the Photon PUN servers and get added to the
  same room.

## Bug Fixes

- Held objects and players no longer clip through static objects.
- Player hand animations are now synced between clients.

## Code review

- https://github.com/UWRealityLab/xrcapstone22wi-team5/pull/1

## Blocking issues

- No blockers to report.