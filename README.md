# Restaurant Template (BE)

![Version](https://img.shields.io/badge/Version-0.1-brightgreen)
![Author](https://img.shields.io/badge/Author-Alessandro-blue)
![Language](https://img.shields.io/badge/Language-C%23-orange)
![FrameWork](https://img.shields.io/badge/Framework-ASP.NET-orange)
[![Open Source? Yes!](https://badgen.net/badge/Open%20Source%20%3F/Yes%21/blue?icon=github)](https://github.com/Naereen/badges/)![68747470733a2f2f696d672e736869656c64732e696f2f62616467652f56657273696f6e2d302e312d627269676874677265656e](https://user-images.githubusercontent.com/66570558/150608946-ef1f1613-9cb3-4427-84cf-7f22c044ba12.svg)


## Description

The BackEnd of a Restaurant/Pizzeria template. Take it to use on you own website

---

### Layer explanation

| Project | Explanation |
| --- | --- |
| RestaurantTemplate | The main project with the controller |
| RestaurantTemplate.BusinessLayer | A class library with all the services of the app |
| RestaurantTemplate.DataAccessLayer | A class library with the setting to connect to DB and all the model of the collection |
| RestaurantTemplate.Shared | A class library with the model for response and request |

### NuGet Packages

![MongoDB.Driver](https://img.shields.io/badge/NuGet%20Package-MongoDB.Driver-cyan)
[MongoDB.Driver](https://www.nuget.org/packages/MongoDB.Driver/)

### MongoDB Collection

To use the project you must create a database named `restaurant` with the following collections:

- menu
- review

The collection are case sensitive so you must respect the lowercase letters

### API Documentation

All the API are documented with the use of Swagger UI

---

## Feature

The site has got a full management system for the menù, image and review of the local. Every feature has is own controller. You can control the data from the admin page

**NOTE:** the admin page isn't already developed

---

## Contribute

If you want to contribute to the project, please open a pull request on this repo.

---

## License
This website is protected under **MIT License**
<br>
&copy; `Alessandro Di Maria` `2022`
