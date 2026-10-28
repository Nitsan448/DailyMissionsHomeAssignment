# How to run

Open the project in Unity, open the MainMenu scene located at Assets/Game/Domains/MainMenu/Scenes and press Play.

Open the missions popup by clicking the missions icon (similar to the real game).

Reset or complete missions through the debug buttons at the left side of the screen.

<img width="281" height="546" alt="image"
src="https://github.com/user-attachments/assets/59b98b8f-f4da-4729-b0e6-edd9b41c7257" />

## General notes

Most of the code is structured using the MVC pattern.

I created the missions system to be extensible and dynamic.
For now it only contains two missions (the manually completed mission, and the streak mission).
But creating new missions should be simple and straightforward.

It should also be fairly simple to extend this system to support defining the missions pool using a JSON config file,
And making it more generic (for example in a "merge 10 times" mission, the 10 would be a value in the config and not
hardcoded).

In a real project I would likely also create a popup system, so that the daily missions popup
will open externally and it will be decoupled from the menu scene, similar to the daily mission view and controller.
But it felt like overkill for this assignment.

## AI Usage

I used AI most extensively for the following scripts:

- List Extensions.
- Factories: Missions Factory, DailyMissionsStreakMissionFactory, ManualMissionFactory.
- All unit tests.

Other than these, I wrote most of the code by hand, but used AI for some straightforward refactorings and logic.
In general, I wrote about 75% of the code, the rest was written by Claude and then reviewed by me and refactored if needed.

As the task was focused on the code, I used AI to help design the UI in Unity.
It was also used for some configs creation, planning and reviews.
