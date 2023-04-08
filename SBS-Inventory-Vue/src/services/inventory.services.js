export function getInventory() {
    return fetch('http://localhost:5227/inventory')
      .then(response => {
        if (response.ok) {
          return response.json();
        } else {
          throw new Error('Failed to fetch inventory data');
        }
      });
  }
  