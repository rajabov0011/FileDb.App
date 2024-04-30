This project is written in ``C#`` and provides the ability to ``Create``, ``Read``, ``Update``, and ``Delete`` (CRUD) Users.

## About the Project

This library uses ``Design Patterns`` to read and write data to ``JSON`` and ``TXT`` files according to standards. This project greatly assists you in managing your ``database``.

### Design Patterns

- **Dependency Injection**: This pattern makes the program structure modular and easy to test. It reduces the dependency of program components on each other.
  
  > In my ``FileDb.App`` project, I solved various problems by referring to a single ``IUSerService`` class to ``.json`` or ``.txt`` files through ``Dependency Injection``.
  - ``JSONStorageBroker`` is implemented from the ``IStorageBroker`` interface.
    <p align="center">
    <img src="" alt="ImplementationJSONStorageBrokerWithIStorageBroker">
    </p>
  - ``FileStorageBroker`` is implemented from the ``IStorageBroker`` interface.
    <p align="center">
    <img src="" alt="ImplementationFileStorageBrokerWithIStorageBroker">
    </p>
  > When communicating with external technologies in our program, we refer to ``Service classes``. Here you can see the ``IUserService`` interface, which contains the common business logic for    ``JSON`` and ``File`` brokers, which have their own logic in the ``Broker`` layer.
- **Dependency Inversion**: This pattern helps in extending and modifying the program structure. It prevents high-level modules from being dependent on low-level modules.
  
  > In our ``FileDb.App`` project, we can observe ``Dependency Inversion`` in the ``Broker`` and ``Service`` layers. That is, through the ``IStorageBroker`` and ``IUserService`` interfaces, we loaded the two layers of the interface into the interface. If we make any changes in the ``Broker`` layer, there will be ``no need to make changes`` in the ``Service``, this is where the principle of ``Dependency Inversion`` helps to clean up the structure of our program more effectively.
- **Singleton Pattern**: This pattern helps in creating ``only one instance`` of a certain type of object. It is useful in managing global data.

  > Let's see how the ``Singleton Pattern`` is implemented in the ``FileDb.App`` project using the ``GetIdentityService()`` method. We can create an object from the ``IdentityService`` class once when the program is running, and we can refer to this object again and again until our program completes its work. Through the ``GetIdentityService()`` method, we can check if the instance of our ``IdentityService`` class has not been created, if the instance is not received, the method will create a new object for us, if it has already been created, the program will return this instance to us.

> [!TIP]
> This is the code example about the application of Singleton Pattern in our FileDb project.
<p align="center">
    <img src="" alt="SingletonPatternIdentityService">
    </p>

  > Let's talk about what the IdentitiyService.cs thread does. This class serves us to create an automatic unique id until we write the User data to a JSON or TXT file, and this is where we need the Singleton Pattern. The program will accurately generate the next id while keeping the previous id.

## Features

- Create User
- Read User data
- Update User data
- Delete User

## Installation

Follow these steps to install and use this library:

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Build the solution to restore the dependencies.
4. Run the project.

## Usage

After launching the application, you will be asked to choose one of the following operations, such as knowing the size of the files, choosing the type of file database you want to use (.TXT or .JSON).
Follow the on-screen instructions to perform CRUD operations on the selected file database.
You can ``create`` new users, ``read`` existing users, ``update`` users and ``delete`` users.

> If you have any questions or suggestions, please feel free to contact the maintainer at rajabov_1999@list.ru.

# Demo
<p align="center">
  <img src="https://github.com/rajabov0011/FileDb.App/blob/master/FileDb.App/Assets/Demos/DEMO.gif" alt="DEMO">
</p>
