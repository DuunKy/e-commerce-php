<?php
$url = 'http://admin_API:8080/api/products';

$curl = curl_init();

curl_setopt_array($curl, array(
    CURLOPT_URL => $url,
    CURLOPT_RETURNTRANSFER => true,
    CURLOPT_ENCODING => "",
    CURLOPT_MAXREDIRS => 10,
    CURLOPT_TIMEOUT => 0,
    CURLOPT_FOLLOWLOCATION => true,
    CURLOPT_HTTP_VERSION => CURL_HTTP_VERSION_1_1,
    CURLOPT_CUSTOMREQUEST => "GET",
    CURLOPT_POSTFIELDS => false,
    CURLOPT_HTTPHEADER => array(),
));

// Exécute la requête et récupère la réponse JSON
$response = curl_exec($curl);

// Vérifie s'il y a des erreurs lors de la requête
if(curl_errno($curl)) {
    echo 'Erreur cURL : ' . curl_error($curl);
}

curl_close($curl);

$products = json_decode($response, true);

if (json_last_error() !== JSON_ERROR_NONE) {
    echo 'Erreur de décodage JSON : ' . json_last_error_msg();
}

// Check si un Product_Type est soumis et affiche selon son filtre
if (isset($_POST['product_type'])) {
    $filteredProducts = array_filter($products, function($product) {
        return $product['Product_Type'] === $_POST['product_type'];
    });
    // Réindexe le tableau après la filtration
    $filteredProducts = array_values($filteredProducts);
} else {
    // Affiche toutes les cartes de produits si rien n'est soumis
    $filteredProducts = $products;
}
?>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
    <script src="https://kit.fontawesome.com/053130d5ea.js" crossorigin="anonymous"></script>
    <link href="css/color.css" rel="stylesheet">
    <link href="css/txt.css" rel="stylesheet">
    <link href="css/navbarIndex.css" rel="stylesheet">
    <link href="css/cardIndex.css" rel="stylesheet">
    <link href="css/headerIndex.css" rel="stylesheet">
    
    
    <title>convert to php</title>
</head> 
<body>
    <!-- START container -->
    <div class="container-fluid p-0">

<!-- START header row -->
<div class="row headerRow"> 

    <div class="col-2">
        <a href="index.php">
            <img src="css/img/theD.png" alt="Logo" class="imgLogo">
        </a>
    </div>

    <div class="col-7 colSearchBar">
        <input type="text" placeholder="Search product..." class="searchBar">
        <button class="buttonSearch"><i class="fa-solid fa-magnifying-glass" style="color:black;"></i></button>
    </div>

    <div class="col-3 colHeader">
                <?php
            if (isset($_SESSION['username'])) {
                // Display the user's name
                echo "<a href='connect.php'><button class='buttonHeader'><i class='fa-solid fa-user' style='color: black;'></i>&nbsp;" . $_SESSION['username'] . "</button></a>";
            } else {
                // Display the "ACCOUNT" button that redirects to connection.php
                echo "<a href='connect.php'><button class='buttonHeader'><i class='fa-solid fa-user' style='color: black;'></i>&nbsp;Account</button></a>";
            }
            ?>

        <a href="/eduncky/site/product.php">
            <button class="buttonHeader"><i class="fa-solid fa-cart-shopping" style="color: black;"></i>&nbsp;ShopList</button>
        </a>
    </div>

</div> <!-- END header row -->



        <!-- START Div Row -->
        <div class="row ">


            <!-- START navbarIndex row -->
            <div class="col-2">
                
                

                    <div class="navContainer p-3">

                    <!-- fORM -->
                    <form id="filter_form" method="post">
                        <input type="hidden" id="product_type" name="product_type">
                    </form>


                            <!--    vetements -->
                            <li class="list">
                                <button class="mainNavButton"  data-type="beer" disabled>Vêtements/beer</button>
                            </li>
                            <li class="list">
                                <button class="secondNavButton"  data-type="Peru" onclick="submitForm('Peru')">&emsp;Haut/peru</button>
                            </li>
                            <li class="list">
                            <button class="secondNavButton"  data-type="PaleVioletRed" onclick="submitForm('PaleVioletRed')">&emsp;Haut/Pale</button>
                            </li>
                            <li class="list">
                                <button class="secondNavButton">&emsp;Casquette</button>
                            </li>
                            <li class="list">
                                <button class="secondNavButton">&emsp;Veste</button>
                            </li>
                            
                            <!--    accesoire -->
                            <li class="list">
                                <button class="mainNavButton" disabled>Accesoire</button>
                            </li>
                            <li class="list">
                                <button class="secondNavButton">&emsp;Mug</button>
                            </li>
                            <li class="list">
                                <button class="secondNavButton">&emsp;Postère</button>
                            </li>
                            <li class="list">
                                <button class="secondNavButton">&emsp;Gourde</button>
                            </li>
                            <li class="list">
                                <button class="secondNavButton">&emsp;testqss</button>
                            </li>
                            
                            
                            <!-- equipement-->
                            <li class="list">
                                <button class="mainNavButton" disabled>Equipement</button>
                            </li>
                            <li class="list">
                                <button class="secondNavButton">&emsp;Clavier</button>
                            </li>
                            <li class="list">
                                <button class="secondNavButton">&emsp;Souris</button>
                            </li>
                            <li class="list">
                                <button class="secondNavButton">&emsp;Tapis de souris</button>
                            </li>
                            <li class="list">
                                <button class="secondNavButton">&emsp;Manette</button>
                            </li>





                            <!-- carte kado-->
                            <li class="list">
                                <button class="mainNavButton" disabled>Carte Cadeau</button>
                            </li>
                            <li class="list">
                                <button class="secondNavButton">&emsp;10euro</button>
                            </li>
                            <li class="list">
                                <button class="secondNavButton">&emsp;25euro</button>
                            </li>
                            <li class="list">
                                <button class="secondNavButton">&emsp;50euro</button>
                            </li>


                    </div>
                    






            

            </div> <!-- END navbarIndex row -->





            

            <div class="col-10"> <!-- START cardIndex row -->
          
       

            <div class="row">
                <?php foreach ($filteredProducts as $productsData): ?>
                    <div class="col-12 col-md-4 pt-4">
                        <a href="product.php?product_id=<?php echo $productsData['Product_Id']; ?>">
                            <div class="card m-3">
                                <img src="css/img/Wanderer.jpg" alt="" class="cardImg">
                                <div class="cardContent text-center">
                                    <cardTxtTitle>
                                        &nbsp;
                                        <?php echo $productsData['Product_Name'] ?>
                                    </cardTxtTitle>
                                    <cardTxtMoney>
                                        <?php echo $productsData['Product_Price'] . ' euro'; ?>
                                        &nbsp;
                                    </cardTxtMoney>
                                    <cardTxt>
                                        <?php echo $productsData['Product_Description']; ?>
                                    </cardTxt>
                                </div>
                            </div>
                        </a>
                    </div>
                <?php endforeach; ?>
            </div>




                </div>



        </div> <!-- END Div Row -->
        










    </div>     <!-- END container -->





 



<script src="js/main.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>

</body>
</html>
