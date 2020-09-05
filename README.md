# Busta Games Unity Utilities
Code I use for my games and game jams.

# Configuring

Some options might work:
- Checkout the code directly into your project folders.
- Use package manager manifest to get from github or directly from your computer.
  - Add one of the following entries 
  - ``` "games.busta.utilities":"file:../../BustaGames.Utilities",```
  - ``` "games.busta.utilities":"https://github.com/ricardobusta/unity-utils",```
- Add a symlink inside the Package folder to your project. 
  - On windows, run admin cmd and use `mklink /D <PATH_INSIDE_PROJECT_PACKAGES> <PATH_TO_REPOSITORY_FILES>`
  - On Mac or Linux, run `ln -s <PATH_TO_REPOSITORY_FILES> <PATH_INSIDE_PROJECT_PACKAGES>`
- Soon: Maybe OpenUPM? 🤷