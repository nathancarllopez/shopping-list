import { API_BASE_URL } from "../constants";

export default async function getFoodItems() {
  const allFoodItems = await fetch(API_BASE_URL);

  if (!allFoodItems.ok) {
    throw new Error('Fetching all food items failed');
  }

  return await allFoodItems.json();
}