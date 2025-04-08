import { API_BASE_URL } from "../constants";

export default async function getFoodItem(id) {
  const foodItem = await fetch(API_BASE_URL + id);

  if (!foodItem.ok) {
    switch(foodItem.status) {
      case 404: {
        throw new Error(`Could not find food item with this id: ${id}`);
      }

      default: {
        throw new Error(`Failed to fetch food items. (status: ${foodItem.status})`);
      }
    }
  }

  return await foodItem.json();
}