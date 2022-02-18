# Week 5 - Multiplayer alpha, MVP kitchen design, and introduction of game management

## What we have accomplished

- Johnathon: Introduced basic sound effects, seasoning, fry spawner, smoke
  effect, game manager object and gameplay logistics, and created the final
  scene for the MVP kitchen
- Katherine: Finished object information ui to be attached to each player and 
  work in multiplayer.
- Laksh: Finished Network Player prefabs textures, fixed photon Voice, implemented
- room joining screen.
- Hritik: Finished pushing fries to the master repo. Started working on
  ticketing system.

## New features/functionality implemented

- All new kitchen! A 3-station kitchen designed from the ground up
- Sound effects! Both ambient noises and context-specific noises have been added
  to the kitchen
- Fry dispensing! Activate the dispenser in the corner to get delicious sliced
  potatoes
- Game elements! The game manager provides orders and evaluates orders that are
  turned in
- Smoke effect! Smoke is produced when searing a steak
- Seasoning and shakers! Salt, pepper, and parsley shakers are now available
- Object information UI! Get temperature, salt levels, and more information about 
  objects
- New UI at the start of the game to join rooms and select your roles. 
- Voice chat implemented 

## Bug Fixes

- Items now stick to plates when in contact. No more sliding around
- Collisions between objects (especially fries) are now much more consistent and
  reliable
- Fixed bug with ladle not updating correctly
- Increased player movement speed
- Fixed Voice chat bug

## Code review

- GameManager.cs: https://github.com/UWRealityLab/xrcapstone22wi-team5/pull/7
- GetInfo.cs: https://github.com/UWRealityLab/xrcapstone22wi-team5/pull/9
- TextInformation.cs: https://github.com/UWRealityLab/xrcapstone22wi-team5/pull/9

## Blocking issues

- Multiplayer functionality: There is currently an issue where an interactable
  object can only be 'owned' by one person per session. This results in multiple
  copies of the same object being in different places for different players.