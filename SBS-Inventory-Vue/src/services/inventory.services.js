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

  export function updateProduct(product) {
    return fetch(`http://localhost:5227/products/update`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(product)
    })
    .then(response => {
      if (response.ok) {
        return response.json();
      } else {
        throw new Error('Failed to update product');
      }
    });
  }
  
  
  export function deleteProductById(productID) {
    return fetch(`http://localhost:5227/products/delete/${productID}`, {
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

  export function getLocations() {
    return fetch('http://localhost:5227/locations')
      .then(response => {
        if (response.ok) {
          return response.json();
        } else {
          throw new Error('Failed to fetch location data');
        }
      });
  }

  export function addLocationByName(locationName) {
    const requestData = {
      locationName: locationName
    };
  
    return fetch('http://localhost:5227/locations/add', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(requestData)
    })
    .then(response => {
      if (response.ok) {
        return response.json();
      } else {
        throw new Error('Failed to add location');
      }
    });
  }

  export function deleteLocationByName(locationName) {
    return fetch(`http://localhost:5227/locations/delete/${locationName}`, {
      method: 'DELETE',
      headers: {
        'Content-Type': 'application/json'
      },
    })
    .then(response => {
      if (response.ok) {
        return response.json();
      } else {
        throw new Error('Failed to delete location');
      }
    });
  }
  