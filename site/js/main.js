function submitForm(productType) {
    // Set the value of the hidden input field
    document.getElementById('product_type').value = productType;
    // Submit the form
    document.getElementById('filter_form').submit();
}