<?php
// Start a session
session_start();

// Initialize the connection variable
$conn = null;

try {
    // Create a new PDO object
    $conn = new PDO('mysql:host=localhost;dbname=duncan', 'tfgi', 'azerty');
    // Set the error mode to exceptions
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
} catch (PDOException $e) {
    // Log the error to a file or database
    error_log("Connection failed: " . $e->getMessage(), 0);
    // Display an error message to the user
    echo "Connection failed. Please try again later.";
    // Exit the script
    exit();
}

// Check if the form was submitted
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Get the username and password from the form
    $username = $_POST["username"];
    $password = $_POST["password"];

    // Check the adminlogin table
    $stmtAdmin = $conn->prepare("SELECT * FROM adminlogin WHERE username_admin=? AND password_admin=?");
    $stmtAdmin->bindParam(1, $username, PDO::PARAM_STR);
    $stmtAdmin->bindParam(2, $password, PDO::PARAM_STR);
    $stmtAdmin->execute();
    $userAdmin = $stmtAdmin->fetchObject();

    // Check the users table
    $stmtUser = $conn->prepare("SELECT * FROM users WHERE User_FirstName=? AND User_Password=?");
    $stmtUser->bindParam(1, $username, PDO::PARAM_STR);
    $stmtUser->bindParam(2, $password, PDO::PARAM_STR);
    $stmtUser->execute();
    $userUser = $stmtUser->fetchObject();

    // If the user is an admin, redirect to the admin page
    if ($userAdmin) {
        // Store the username in a session variable
        $_SESSION['username'] = $username;
        // Redirect to the admin page
        header("location: admintemplate/adminindex.html");
        // Exit the script
        exit();
    }

    // If the user is a regular user, redirect to the product page
    if ($userUser) {
        // Store the username in a session variable
        $_SESSION['username'] = $username;
        // Redirect to the product page
        header("location: index.php");
        // Exit the script
        exit();
    }

    // If the user is not found, display an error message
    echo "Invalid username or password.";
}

// Check if the logout button was clicked
if (isset($_POST['logout'])) {
    // Destroy the session
    session_destroy();
    // Redirect to the login page
    header("location: connect.php");
    // Exit the script
    exit();
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
    <script src="https://kit.fontawesome.com/053130d5ea.js" crossorigin="anonymous"></script>

    <link href="site/txt.css" rel="stylesheet">
    <link href="site/color.css" rel="stylesheet">
    <link href="css/formConnect.css" rel="stylesheet">
    <link href="css/headerConnect.css" rel="stylesheet">
    <link href="css/headerIndex.css" rel="stylesheet">

    <title>convert to php</title>
</head>
<body>

<div class="container-fluid d-flex flex-column vh-100 ">

    <!-- Header START -->
    <div class="row headerRow">



        <div class="col-12 col-md-4 logoContainer">
            <a href="/eduncky/site/index.php">
                <img src="css/img/theD.png" alt="Logo" class="imgLogo">
            </a>
        </div>



        <div class="col-4">
        </div>

        <div class="col-4 pt-3">
        <?php
            if (isset($_SESSION['username'])) {
                // Display the user's name
                echo "<form action='" . $_SERVER['PHP_SELF'] . "' method='post'>";
                echo "<button type='submit' name='logout' class='buttonHeader'><i class='fa-solid fa-user' style='color: black;'></i>&nbsp;Deconnection</button>";
                echo "</form>";

            } else {
                #HERE
            }
            ?>
        </div>

    </div> <!-- Header END -->








    <!-- connect START -->
    <div class="row connectRow flex-grow-1 text-center   ">

        <div class="col-3">
        </div>


        <div class="col-6 formContainer">

            <?php
            // Check if the session variable is set
            if (isset($_SESSION['username'])) {
                // Display the user's name
                echo "<p>Tu es deja connecté, " . $_SESSION['username'] . " va depenser de l'argent " ."</p>";
            } else {
                // Display the login form
                echo "<form action='" . $_SERVER['PHP_SELF'] . "' method='post' id='contactForm'>";

                echo "<div class=\"row\">";
                echo "<div class=\"col-12\">";
                echo "<formTitle>Connection / inscription </formTitle>";
                echo "<p>Saisissez votre e-mail pour vous connecter ou créer un compte</p>";
                echo "</div>";
                echo "<div class=\"col-12  text-center  p-4 containerConnect \">";
                echo "<div class=\"col-12 \">";
                echo "<input type=\"text\" class=\"formAbout\" placeholder=\"Username\" name=\"username\" required>";
                echo "</div>";
                echo "<div class=\"col-12 pt-2 \">";
                echo "<input type=\"password\" class=\"formAbout\" placeholder=\"Password\" name=\"password\" required>";
                echo "</div>";
                echo "<div class=\"col-12 pt-3\">";
                echo "<input type=\"submit\" class=\"buttonForm\" value=\" Connection \">";
                echo "</div>";
                echo "<div class=\"col-12 pt-2\">";
                echo "<a href=\"inscription.php\" class=\"hyperlink\">Create account</a>";
                echo "</div>";
                echo "</div>";
                echo "</div>";
                echo "</form>";
            }
            ?>

        </div>


        <div class="col-3">
        </div>

    </div> <!-- connect END -->



</div> <!-- Container END -->










<script src="js/main.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>


</body>
</html>
