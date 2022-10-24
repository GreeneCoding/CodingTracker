# CodingTracker
This was my first console project which required Separtion of Concerns

# Project Requirements:


    1. This application has the same requirements as the previous project, except that now you'll be logging your daily coding time.
    2. To show the data on the console, you should use the "ConsoleTableExt" library.
    3. You're required to have separate classes in different files (ex. UserInput.cs, Validation.cs, CodingController.cs)
    4. You should tell the user the specific format you want the date and time to be logged and not allow any other format.
    5. You'll need to create a configuration file that you'll contain your database path and connection strings.
    6. You'll need to create a "CodingSession" class in a separate file. It will contain the properties of your coding session: Id, StartTime, EndTime, Duration.
    7. The user shouldn't input the duration of the session. It should be calculated based on the Start and End times, in a separate "CalculateDuration" method.
    8. The user should be able to input the start and end times manually.
    9. When reading from the database, you can't use an anonymous object, you have to read your table into a List of Coding Sessions.

# Features:

- Automagic creating of SQLitedatabase and table, if no database/table exists for tracking Coding Sessions.

- Console based interface with key presses for app navigation.

- CRUD Database functions for adding, reading, updating and deleting records. 
  - Id's are validated to confirm they exist and that strings have not been entered, before update or delete commands are completed. 
    - Start times and end times are validated to be in the format "MM/dd/yyyy HH:mm",, before create or update commands are completed.
      - end times are validated to be later than start times.

- CodingSessions table presented in a more human readable format via the ConsoleTableExt library.

# Project Ending Notes
Coming into this project, I felt very overwhelmed with the idea of separation of concerns, however, after completing my first project using these principles, I see the power in having a more well organized and reusable coding structure.
