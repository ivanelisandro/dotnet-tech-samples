# Routing and Navigation sample

A simple project to explore the routing and navigation options in Blazor.

## Objectives

- Explore usage of components;
- Explore usage of route templates with parameters;
- Explore usage of `<NavLink />`;
- Explore usage of forms with `<EditForm />`;
- Explore parameter validation with `DataAnnotation` and `<DataAnnotationsValidator />`;

## Test Cases

1. View `Recipes`:

    - Run the application;
    - In the side menu, click `Recipes`:
      - The application should show a list of predefined recipes;
      - Each item should show:
        - The recipe name;
        - A button to navigate to the specific page;
      - There should also be one button to navigate to the `Add Recipe` form;

2. View `Recipe Items` submenu:

    - Run the application;
    - In the side menu, click `Recipe Items`:
      - The menu should expand to show a submenu of the recipe items;
      - Menu should use the names of recipes for the items;
      - Leaving the mouse over the submenu item should show a tooltip with the recipe name;
    - In the side menu, click `Recipe Items` again:
      - The submenu should collapse, returning the menu to the original stage;

3. View recipe details:

    - Run the application;
    - In the side menu, click `Recipes`:
      - The application should show a list of predefined recipes;
    - Click `View Details` for any item;
      - The application should navigate to the correct recipe details page;
    - Click `Return to Recipes` in the recipe details page;
      - The application should navigate back to the `Recipes` page;
    - In the side menu, click `Recipe Items`;
    - Click any item in the submenu;
      - The application should navigate to the correct recipe details page;
    - Click `Return to Recipes` in the recipe details page;
      - The application should navigate back to the `Recipes` page;

4. View `Add Recipe`:

    - Run the application;
    - In the side menu, click `Add Recipe`:
      - The form should have fields for:
        - Recipe name;
        - Recipe description;
      - The form should have a submit button;

5. Validate adding recipe:

    - Run the application;
    - In the side menu, click `Add Recipe`:
      - The form should have a fields for:
        - Recipe name;
        - Recipe description;
    - Try to submit an empty recipe;
      - The form should block submission with errors for empty name and empty description;
    - Fill the recipe name;
    - Try to submit with recipe description empty;
      - The form should block submission with error for empty description;
    - Erase the recipe name;
    - Fill the recipe description;
    - Try to submit with recipe name empty;
      - The form should block submission with error for empty name;
    - Fill the form with valid values:
      - Name: Honey BBQ Chicken Wings
      - Description: Crispy baked wings coated in a sweet and smoky honey BBQ sauce.
    - Click `Add Recipe`:
      - Submission should be successful;
      - The application should redirect to the `Recipes` page;
      - The added recipe should be present in the recipes list;
    - View `Recipe Items` in the side menu:
      - The added recipe should be present in the submenu;
      - The submenu should use ellypsis when the recipe name overflows the component;
      - Leaving the mouse over the submenu item should show a tooltip with the full recipe name;
