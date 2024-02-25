<?php
// connection to the phpmyadmin db with xampp
$db = new PDO('mysql:host=localhost;dbname=eduncky', 'tfgi', 'azerty');


if (isset($_GET['product_id'])) {
    // Get the product details from the database based on the product_id
    $queryProduct = $db->prepare('SELECT * FROM products WHERE Product_Id = :product_id');
    $queryProduct->bindParam(':product_id', $_GET['product_id']);
    $queryProduct->execute();
    $product = $queryProduct->fetch(PDO::FETCH_ASSOC);


} else {
    echo 'Product ID not provided';
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
    <link href="css/cardProduct.css" rel="stylesheet">
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
                
                    <a href="/eduncky/site/connect.php">
                        <button class="buttonHeader"><i class="fa-solid fa-user" style="color: black;"></i>&nbsp;Account</button>
                    </a>
                    
                    <a href="/eduncky/site/product.php">
                        <button class="buttonHeader"><i class="fa-solid fa-cart-shopping" style="color: black;"></i>&nbsp;ShopList</button>
                    </a>
            </div>

        </div> <!-- END header row -->






            

            <div class="col-12"> <!-- START cardProduct row -->
          
                <div class="row">

                    <div class="col-2">
                         
                    </div>

                    <div class="col-4 ">
                        <div class="leftProduct text-end pt-5">
                            <img src="css/tools/img/Wanderer.jpg" alt="" class="cardImg">
                        </div>
                        
                    </div>

                    <div class="col-4 text-start pt-5">
                        <div class="rightProduct">
                            <div class="row m-5">
                                <div class="col-12">

                                    <div class="txtProduct ">
                                        <txtProductType>
                                            > 
                                            <?php echo $product['Product_Type'] ?>
                                        </txtProductType>
                                        <br>

                                        <txtProductName>
                                            
                                            <?php echo $product['Product_Name'] ?>
                                        </txtProductName>
                                        <br>

                                        <txtProductPrice>
                                            Price : 
                                            
                                            <?php echo $product['Product_Price'] ?>
                                            euro
                                        </txtProductPrice>
                                        <br>

                                    </div>
                        

                                </div>

                            <div class="col-12 pt-5">
                                <a href="">
                                    <button class="buttonProduct"><i class="fa-solid fa-cart-shopping" style="color: black;"></i>&nbsp;Add to Shoplist</button>
                                </a>
                            </div>

                                
                            <div class="col-12 pt-5">
                                
                                <?php echo $product['Product_Description'] ?>
                            </div>


                        </div>
 
                    <div class="col-2">
                    </div>


                    </div>
                </div>

    


            </div> <!-- END cardProduct row -->



        










    </div>     <!-- END container -->





 


<script src="js/main.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>

</body>
</html>
