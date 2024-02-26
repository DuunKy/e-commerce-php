<?php
$conn = "";

try {
    $conn = new PDO('mysql:host=localhost;dbname=duncan', 'tfgi', 'azerty');
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
} catch (PDOException $e) {
    echo "Connection failed: " . $e->getMessage();
}

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $email = $_POST["email"];
    $firstName = $_POST["firstName"];
    $password = $_POST["password"];
    
    // Insert a new row into the users table
    $stmt = $conn->prepare("INSERT INTO users (User_Email, User_FirstName, User_Password) VALUES (?, ?, ?)");
    $stmt->bindParam(1, $email, PDO::PARAM_STR);
    $stmt->bindParam(2, $firstName, PDO::PARAM_STR);
    $stmt->bindParam(3, $password, PDO::PARAM_STR);
    $stmt->execute();
    
    // Redirect
    header("location: connect.php");
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

        <div class="col-4">
        </div>

    </div> <!-- Header END -->








    <!-- connect START -->
    <div class="row connectRow flex-grow-1 text-center   ">

        <div class="col-3">
        </div>


        <div class="col-6 formContainer">


            <form action="<?php echo $_SERVER['PHP_SELF']; ?>" method="post" id="contactForm">


                <div class="row ">


                    <div class="col-12">
                        <formTitle>Création de compte </formTitle>
                        <p>Saisissez vos informations</p>
                    </div>



                    <div class="col-12  text-center  p-4 containerConnectInscription ">


                        <div class="col-12 ">
                            <input type="email" class="formAbout" placeholder="Email" name="email" required>
                        </div>

                        <div class="col-12 pt-5 ">
                            <input type="text" class="formAbout" placeholder="Username" name="firstName" required>
                        </div>
    
                        <div class="col-12 pt-5 ">
                            <input type="password" class="formAbout" placeholder="Mot de passe" name="password" required>
                        </div>  
    
                            
                        <div class="col-12 pt-4">
                            <input type="submit" class="buttonForm"  value=" Créer mon compte ">
                        </div>

                            

                    </div>



                </div>

            </form>

        </div>


        <div class="col-3">
        </div>

    </div> <!-- connect END -->

    <!-- Popup message -->
    <div id="popup" style="display: none;">
        <p>Wrong information. Please try again.</p>
    </div>

</div> <!-- Container END -->










<script src="js/main.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>

<!-- JavaScript code to show/hide the popup -->


</body>
</html>
