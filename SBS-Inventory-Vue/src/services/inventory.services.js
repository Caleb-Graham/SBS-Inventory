export function getProducts() {
    return fetch('http://localhost:5227/Products')
      .then(response => {
        if (response.ok) {
          return response.json();
        } else {
          throw new Error('Failed to fetch inventory data');
        }
      });
  }

  export function getProductById(id) {
    return fetch(`http://localhost:5227/Products/${id}`)
      .then(response => {
        if (response.ok) {
          return response.json();
        } else {
          throw new Error('Failed to fetch product data');
        }
      });
  }
  
  
  export function addProduct(product) {
    return fetch('http://localhost:5227/Products', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(product)
    })
    .then(response => {
      if (response.ok) {
        return response.json();
      } else {
        throw new Error('Failed to add product');
      }
    });
  }
  
  export function deleteProductById(id) {
    return fetch(`http://localhost:5227/Products/${id}`, {
      method: 'DELETE',
      headers: {
        'Content-Type': 'application/json'
      },
    })
    .then(response => {
      if (response.ok) {
        return response.json();
      } else {
        throw new Error('Failed to delete product');
      }
    });
  }
  