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
  