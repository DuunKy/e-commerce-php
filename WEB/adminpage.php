<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <!--<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">-->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" href="assets/css/bootstrap.css">
    <link rel="stylesheet" href="assets/admin.css">
    <title>Dashboard Admin page</title>
</head>

<body>
    <div>
        <a href="http://localhost:8080/api/status">Check API Status</a>
        <div class="crud-box">
            <h3>Users</h3>
            <p>
                <a class="btn btn-primary" data-toggle="collapse" href="#multiCollapseExample1" role="button" aria-expanded="false" aria-controls="multiCollapseExample1">Create</a>
                <!--<a class="btn btn-primary" data-toggle="collapse" data-target="#multiCollapseExample2" role="button" aria-expanded="false" aria-controls="multiCollapseExample2">Read</a>-->
                <a class="btn btn-primary" role="button" href="http://localhost:8080/api/users/1">Read ( first user )</a>
                <a class="btn btn-primary" data-toggle="collapse" data-target="#multiCollapseExample3" role="button" aria-expanded="false" aria-controls="multiCollapseExample3">Update</a>
                <a class="btn btn-primary" data-toggle="collapse" data-target="#multiCollapseExample4" role="button" aria-expanded="false" aria-controls="multiCollapseExample4">Delete</a>
                <!--<button class="btn btn-primary" type="button" data-toggle="collapse" data-target=".multi-collapse" aria-expanded="false" aria-controls="multiCollapseExample1 multiCollapseExample2">Toggle both elements</button>-->
            </p>
            <div class="row">
                <div class="col">
                    <div class="collapse multi-collapse" id="multiCollapseExample1">
                        <div class="card card-body">
                            <form action="http://localhost:8080/api/user" method="post" class="form">
                                <div class="form">
                                    <label>Enter your FirstName: </label>
                                    <input type="text" name="User_FirstName" required />
                                </div>
                                <div class="form">
                                    <label>Enter your LastName: </label>
                                    <input type="text" name="User_LastName" required />
                                </div>
                                <div class="form">
                                    <label>Enter your Email: </label>
                                    <input type="email" name="User_Email" required />
                                </div>
                                <div class="form">
                                    <label>Enter your Password: </label>
                                    <input type="password" name="User_Password" required />
                                </div>
                                <div class="form">
                                    <label>Enter your Phone: </label>
                                    <input type="tel" name="User_Phone" pattern="[0-9]{10}" required />
                                </div>
                                <div class="form">
                                    <input type="submit" value="Send" />
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
<!--                <div class="col">
                    <div class="collapse multi-collapse" id="multiCollapseExample2">
                        <div class="card card-body">
                        </div>
                    </div>
                </div>
            </div>-->
                <div class="col">
                    <div class="collapse multi-collapse" id="multiCollapseExample3">
                        <div class="card card-body">
                            <form action="http://localhost:8080/api/user" method="put" class="form">
                                <div class="form">
                                    <label>Enter your FirstName: </label>
                                    <input type="text" name="User_FirstName" required />
                                </div>
                                <div class="form">
                                    <label>Enter your LastName: </label>
                                    <input type="text" name="User_LastName" required />
                                </div>
                                <div class="form">
                                    <label>Enter your Email: </label>
                                    <input type="email" name="User_Email" required />
                                </div>
                                <div class="form">
                                    <label>Enter your Password: </label>
                                    <input type="password" name="User_Password" required />
                                </div>
                                <div class="form">
                                    <label>Enter your Phone: </label>
                                    <input type="tel" name="User_Phone" pattern="[0-9]{10}" required />
                                </div>
                                <div class="form">
                                    <input type="submit" value="Send" />
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="collapse multi-collapse" id="multiCollapseExample4">
                    <div class="card card-body">
                        <form action="http://localhost:8080/api/user" method="delete" class="form">
                            <div class="form">
                                <label>Enter your FirstName: </label>
                                <input type="text" name="User_FirstName" required />
                            </div>
                            <div class="form">
                                <label>Enter your LastName: </label>
                                <input type="text" name="User_LastName" required />
                            </div>
                            <div class="form">
                                <label>Enter your Email: </label>
                                <input type="email" name="User_Email" required />
                            </div>
                            <div class="form">
                                <label>Enter your Password: </label>
                                <input type="password" name="User_Password" required />
                            </div>
                            <div class="form">
                                <label>Enter your Phone: </label>
                                <input type="tel" name="User_Phone" pattern="[0-9]{10}" required />
                            </div>
                            <div class="form">
                                <input type="submit" value="Send" />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <div class="crud-box">
            <h3>Products</h3>
            <form action="crudProducts.php" method="POST">
                <input class="button" type="submit" value="Create" />
                <input class="button" type="submit" value="Read" />
                <input class="button" type="submit" value="Update" />
                <input class="button" type="submit" value="Delete" />
            </form>
        </div>
    </div>


<!--<form action="validate.php" method="post">
    <div class="login-box">
        <h1>Dashboard</h1>

        <div class="textbox">
            <i class="fa fa-user" aria-hidden="true"></i>
            <input type="text" placeholder="Username"
                   name="username" value="">
        </div>

        <div class="textbox">
            <i class="fa fa-lock" aria-hidden="true"></i>
            <input type="password" placeholder="Password"
                   name="password" value="">
        </div>

        <input class="button" type="submit"
               name="login" value="Sign In">
    </div>
</form>-->
</body>

</html>